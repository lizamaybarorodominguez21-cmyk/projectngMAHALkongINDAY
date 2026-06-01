# Google Offline Dino Clone (Tkinter)


import tkinter as tk
import random

# ======================================
# WINDOW
# ======================================
WIDTH = 1000
HEIGHT = 400
GROUND_Y = 320

root = tk.Tk()
root.title("Offline Dino Game")
root.resizable(False, False)

canvas = tk.Canvas(
    root,
    width=WIDTH,
    height=HEIGHT,
    bg="white",
    highlightthickness=0
)
canvas.pack()

# ======================================
# GAME VARIABLES
# ======================================
score = 0
high_score = 0
speed = 8

game_running = True
jumping = False
jump_velocity = 0
gravity = 0.9

night_mode = False

obstacles = []
clouds = []
birds = []

# ======================================
# GROUND
# ======================================
canvas.create_line(
    0,
    GROUND_Y,
    WIDTH,
    GROUND_Y,
    fill="black",
    width=3
)

# ======================================
# SCORE UI
# ======================================
score_text = canvas.create_text(
    700,
    30,
    text="00000",
    fill="#444",
    font=("Consolas", 22, "bold")
   
)

high_score_text = canvas.create_text(
    880,
    30,
    text="HI 00000",
    fill="#444",
    font=("Consolas", 22, "bold")
    
)

for i in range(0, WIDTH, 20):

    canvas.create_oval(
        i,
        GROUND_Y + 10,
        i + 3,
        GROUND_Y + 13,
        fill="#777",
        outline=""
    )

# ======================================
# DINO
# ======================================

DINO_PARTS = []

# BODY
body = canvas.create_rectangle(
    80, GROUND_Y - 45,
    115, GROUND_Y - 10,
    fill="#444", outline="#444"
)

# HEAD
head = canvas.create_rectangle(
    105, GROUND_Y - 65,
    130, GROUND_Y - 35,
    fill="#444", outline="#444"
)

# MOUTH
mouth = canvas.create_line(
    120, GROUND_Y - 45,
    130, GROUND_Y - 45,
    fill="white",
    width=2
)

# EYE
eye = canvas.create_rectangle(
    118, GROUND_Y - 58,
    122, GROUND_Y - 54,
    fill="white",
    outline="white"
)

# ARMS
arm1 = canvas.create_line(
    105, GROUND_Y - 25,
    95, GROUND_Y - 20,
    fill="#444",
    width=4
)

arm2 = canvas.create_line(
    105, GROUND_Y - 18,
    95, GROUND_Y - 15,
    fill="#444",
    width=4
)

# LEGS
leg1 = canvas.create_line(
    90, GROUND_Y - 10,
    90, GROUND_Y,
    fill="#444",
    width=5
)

leg2 = canvas.create_line(
    105, GROUND_Y - 10,
    105, GROUND_Y,
    fill="#444",
    width=5
)

# TAIL
tail = canvas.create_polygon(
    80, GROUND_Y - 30,
    65, GROUND_Y - 40,
    75, GROUND_Y - 20,
    fill="#444",
    outline="#444"
)

DINO_PARTS = [
    body, head, mouth,
    eye, arm1, arm2,
    leg1, leg2, tail
]

# Invisible collision box
dino = canvas.create_rectangle(
    70,
    GROUND_Y - 65,
    130,
    GROUND_Y,
    outline="",
    fill=""
)

# ======================================
# CLOUDS
# ======================================
def create_cloud():


    x = WIDTH + 50
    y = random.randint(40, 120)

    cloud = canvas.create_text(
        x,
        y,
        text="☁",
        fill="#cfcfcf",
        font=("Arial", 28)
    )

    clouds.append(cloud)

# ======================================
# CACTUS
# ======================================

def create_obstacle():

    cactus = []

    x = WIDTH + random.randint(0, 200)

    obstacle_type = random.choice([
        "small",
        "big",
        "double"
    ])

    # =========================
    # SMALL CACTUS
    # =========================
    if obstacle_type == "small":

        body = canvas.create_rectangle(
            x,
            GROUND_Y - 40,
            x + 15,
            GROUND_Y,
            fill="#444",
            outline="#444"
        )

        arm = canvas.create_rectangle(
            x - 8,
            GROUND_Y - 30,
            x,
            GROUND_Y - 20,
            fill="#444",
            outline="#444"
        )

        cactus.extend([body, arm])

    # =========================
    # BIG CACTUS
    # =========================
    elif obstacle_type == "big":

        body = canvas.create_rectangle(
            x,
            GROUND_Y - 60,
            x + 20,
            GROUND_Y,
            fill="#444",
            outline="#444"
        )

        left_arm = canvas.create_rectangle(
            x - 10,
            GROUND_Y - 45,
            x,
            GROUND_Y - 30,
            fill="#444",
            outline="#444"
        )

        right_arm = canvas.create_rectangle(
            x + 20,
            GROUND_Y - 35,
            x + 30,
            GROUND_Y - 20,
            fill="#444",
            outline="#444"
        )

        cactus.extend([
            body,
            left_arm,
            right_arm
        ])

    # =========================
    # DOUBLE CACTUS
    # =========================
    elif obstacle_type == "double":

        for i in range(2):

            offset = i * 25

            body = canvas.create_rectangle(
                x + offset,
                GROUND_Y - 45,
                x + 15 + offset,
                GROUND_Y,
                fill="#444",
                outline="#444"
            )

            cactus.append(body)

    obstacles.append(cactus)

# ======================================
# FLYING BIRD
# ======================================

def create_bird():

    bird_parts = []

    x = WIDTH + 50

    y = random.choice([
        GROUND_Y - 120,
        GROUND_Y - 160,
        GROUND_Y - 200
    ])

    # Body
    body = canvas.create_rectangle(
        x,
        y,
        x + 30,
        y + 15,
        fill="#444",
        outline="#444"
    )

    # Wing
    wing = canvas.create_polygon(
        x + 10, y + 5,
        x + 20, y - 10,
        x + 25, y + 5,
        fill="#444",
        outline="#444"
    )

    bird_parts.extend([
        body,
        wing
    ])

    birds.append(bird_parts)

# ======================================
# COLLISION
# ======================================
def check_collision(a, b):

    return (
        a[2] > b[0] and
        a[0] < b[2] and
        a[3] > b[1] and
        a[1] < b[3]
    )

# ======================================
# JUMP
# ======================================
def jump(event=None):

    global jumping
    global jump_velocity

    if not jumping and game_running:

        jumping = True
        jump_velocity = -15

root.bind("<space>", jump)
root.bind("<Up>", jump)

# ======================================
# GAME OVER
# ======================================
def game_over():

    global game_running
    global high_score

    game_running = False

    if score > high_score:
        high_score = score

    canvas.itemconfig(
        high_score_text,
        text=f"HI {high_score:05}"
    )

    canvas.create_text(
        WIDTH//2,
        130,
        text="GAME OVER",
        fill="red",
        font=("Consolas", 40, "bold"),
        tag="gameover"
    )

    canvas.create_text(
        WIDTH//2,
        180,
        text="PRESS R TO RESTART",
        fill="black",
        font=("Consolas", 20),
        tag="gameover"
    )

# ======================================
# RESTART
# ======================================


def restart(event=None):

    global score
    global speed
    global game_running
    global obstacles
    global jumping
    global jump_velocity
    global birds

    if game_running:
        return

    canvas.delete("gameover")

    for obstacle in obstacles:
        for part in obstacle:
            canvas.delete(part)

    obstacles.clear()

    for bird in birds:
        for part in bird:
            canvas.delete(part)
    birds.clear()

    score = 0
    speed = 8

    jumping = False
    jump_velocity = 0

    dino_pos = canvas.coords(dino)

    offset_y = dino_pos[3] - GROUND_Y

    for part in DINO_PARTS:
        canvas.move(part, 0, -offset_y)

    canvas.coords(
        dino,
        70,
        GROUND_Y - 65,
        130,
        GROUND_Y
    )

    game_running = True

    update_game()

root.bind("r", restart)
root.bind("R", restart)

# ======================================
# DAY / NIGHT MODE
# ======================================
def update_day_night():

    global night_mode

    # Every 30 score switch mode
    new_mode = (score // 30) % 2 == 1

    if new_mode != night_mode:

        night_mode = new_mode

        # =========================
        # NIGHT MODE
        # =========================
        if night_mode:

            canvas.config(bg="#1e1e1e")

            # Ground
            canvas.create_line(
                0,
                GROUND_Y,
                WIDTH,
                GROUND_Y,
                fill="white",
                width=3,
                tag="groundline"
            )

            # Score color
            canvas.itemconfig(score_text, fill="white")
            canvas.itemconfig(high_score_text, fill="white")

            # Dino parts
            for part in DINO_PARTS:
                try:
                    canvas.itemconfig(part, fill="white")
                except:
                    pass

            # Obstacles
            for obstacle in obstacles:
                for part in obstacle:
                    try:
                        canvas.itemconfig(part, fill="white")
                    except:
                        pass

            # Birds
            for bird in birds:
                for part in bird:
                    try:
                        canvas.itemconfig(part, fill="white")
                    except:
                        pass

        # =========================
        # DAY MODE
        # =========================
        else:

            canvas.config(bg="white")

            canvas.create_line(
                0,
                GROUND_Y,
                WIDTH,
                GROUND_Y,
                fill="black",
                width=3,
                tag="groundline"
            )

            canvas.itemconfig(score_text, fill="#444")
            canvas.itemconfig(high_score_text, fill="#444")

            for part in DINO_PARTS:
                try:
                    canvas.itemconfig(part, fill="#444")
                except:
                    pass

            for obstacle in obstacles:
                for part in obstacle:
                    try:
                        canvas.itemconfig(part, fill="#444")
                    except:
                        pass

            for bird in birds:
                for part in bird:
                    try:
                        canvas.itemconfig(part, fill="#444")
                    except:
                        pass

# ======================================
# GAME LOOP
# ======================================
def update_game():

    global jumping
    global jump_velocity
    global score
    global speed

    if not game_running:
        return

    # =============================
    # JUMP PHYSICS
    # =============================
    if jumping:

        # Move invisible hitbox
        canvas.move(dino, 0, jump_velocity)

        # Move all dino parts
        for part in DINO_PARTS:
            canvas.move(part, 0, jump_velocity)

        jump_velocity += gravity

        pos = canvas.coords(dino)

        if pos[3] >= GROUND_Y:

            difference = pos[3] - GROUND_Y
            canvas.move(dino, 0, -difference)

            for part in DINO_PARTS:
                canvas.move(part, 0, -difference)

            jumping = False
            jump_velocity = 0

    # =============================
    # MOVE OBSTACLES
    # =============================
    for obstacle in obstacles[:]:

        for part in obstacle:
            canvas.move(part, -speed, 0)

        obstacle_pos = canvas.coords(obstacle[0])

        if obstacle_pos[2] < 0:

            for part in obstacle:
                canvas.delete(part)

            obstacles.remove(obstacle)

            score += 1

            canvas.itemconfig(
                score_text,
                text=f"{score:05}"
            )

            if score % 10 == 0:
                speed += 0.3

    # =============================
    # MOVE CLOUDS
    # =============================
    for cloud in clouds[:]:

        canvas.move(cloud, -2, 0)

        cloud_pos = canvas.coords(cloud)

        if cloud_pos[0] < -50:

            canvas.delete(cloud)
            clouds.remove(cloud)

    # =============================
    # RANDOM CLOUDS
    # =============================
    if random.randint(1, 120) == 1:
        create_cloud()

    if score > 20:

        if random.randint(1, 250) == 1:

            if len(birds) < 2:
                create_bird()

    # =============================
    # RANDOM OBSTACLES
    # =============================
    if len(obstacles) == 0:

        create_obstacle()

    else:
        last_obstacle_pos = canvas.coords(obstacles[-1][0])

        dynamic_distance = random.randint(
            max(180, 400 - score),
            max(250, 600 - score)

        )

        if last_obstacle_pos[0] < WIDTH - dynamic_distance:

            if score >= 20 and random.randint(1, 4) == 1:
                
                if len(birds) == 0:
                    create_bird()

            else:
                create_obstacle()
    
    # =============================
    # MOVE BIRDS
    # =============================
    for bird in birds[:]:

        for part in bird:
            canvas.move(part, -speed - 2, 0)

        bird_pos = canvas.coords(bird[0])

        if bird_pos[2] < 0:

            for part in bird:
                canvas.delete(part)

            birds.remove(bird)


    # =============================
    # COLLISION
    # =============================
    dino_pos = canvas.coords(dino)

    for bird in birds:

        bird_pos = canvas.coords(bird[0])

        if check_collision(dino_pos, bird_pos):
            game_over()
            return
        
    for obstacle in obstacles:

        obstacle_pos = canvas.coords(obstacle[0])

        if check_collision(dino_pos, obstacle_pos):
            game_over()
            return

    # =============================
    # LOOP
    # =============================
    update_day_night()
    root.after(10, update_game)

# ======================================
# START
# ======================================
update_game()

root.mainloop()
